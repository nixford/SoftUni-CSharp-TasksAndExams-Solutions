﻿using SIS.HTTP.Enums;
using SIS.HTTP.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace SIS.HTTP.HttpElements
{
    public class HttpRequest
    {
        public HttpRequest(string httpRequestAsString)
         {
            this.Headers = new List<Header>();
            this.Cookies = new List<Cookie>();
            this.SessionData = new Dictionary<string, string>();            
            // StringReader reader = new StringReader(httpRequestAsString);
            // reader.ReadLine();

            var lines = httpRequestAsString.Split(
                new string[] { HttpConstants.NewLine },
                StringSplitOptions.None);
            var httpInfoHeader = lines[0];
            var infoHttpInfoHeaderParts = httpInfoHeader.Split(' ');
            if (infoHttpInfoHeaderParts.Length != 3)
            {
                throw new HttpServerException("Invalid HTTP header line!");
            }

            var httpMethod = infoHttpInfoHeaderParts[0];

            //Enum.TryParse(httpMethod, out HttpMethodType type);
            //this.Method = type;

            this.Method = httpMethod switch
            {
                "GET" => HttpMethodType.Get,
                "POST" => HttpMethodType.Post,
                "PUT" => HttpMethodType.Put,
                "DELETE" => HttpMethodType.Delete,
                _ => HttpMethodType.Unknown,
            };

            this.Path = infoHttpInfoHeaderParts[1];

            var httpVersion = infoHttpInfoHeaderParts[2];
            //Enum.TryParse(httpVersion, out HttpVersionType versionType);
            //this.Version = versionType;

            this.Version = httpVersion switch
            {
                "HTTP/1.0" => HttpVersionType.Http10,
                "HTTP/1.1" => HttpVersionType.Http11,
                "HTTP/2.0" => HttpVersionType.Http20,
                _ => HttpVersionType.Http10,
            };

            StringBuilder bodyBuilder = new StringBuilder();
            bool isInHeader = true;
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeader = false;
                    continue;
                }

                if (isInHeader)
                {
                    var headerParts = line.Split
                        (new string[] { ": " }, 
                        2, 
                        StringSplitOptions.None);

                    if (headerParts.Length != 2)
                    {
                        throw new HttpServerException
                            ($"Invalid header: {line}");
                    }

                    var header = new Header(headerParts[0], headerParts[1]);
                    this.Headers.Add(header);

                    if (headerParts[0] == "Cookie")
                    {
                        var cookiesAsString = headerParts[1];
                        var cookies = cookiesAsString
                            .Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var cookieAsString in cookies)
                        {
                            var cookieParts = cookieAsString
                                .Split(new char[] { '=' }, 2);
                            if (cookieAsString.Length == 2)
                            {
                                this.Cookies.Add(new Cookie(cookieParts[0], cookieParts[1]));
                            }
                        }
                    }
                }
                else
                {
                    bodyBuilder.AppendLine(line);
                }

                this.Body = bodyBuilder.ToString().TrimEnd('\r', '\n');
                this.FormData = new Dictionary<string, string>();
                var bodyParts = this.Body.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var bodyPart in bodyParts)
                {
                    var parameterParts = bodyPart.Split(new char[] { '=' }, 2);
                    this.FormData.Add(
                       HttpUtility.UrlDecode(parameterParts[0]),
                       HttpUtility.UrlDecode(parameterParts[1]));
                }
            }
        }

        public HttpMethodType Method { get; set; }
        // There is ready calss of HttpMethod

        public string Path { get; set; }

        public HttpVersionType Version { get; set; }

        public IList<Header> Headers { get; set; }

        public IList<Cookie> Cookies { get; set; }

        public string Body { get; set; }

        public IDictionary<string, string> FormData { get; set; }

        public IDictionary<string, string> SessionData { get; set; }
    }
}
