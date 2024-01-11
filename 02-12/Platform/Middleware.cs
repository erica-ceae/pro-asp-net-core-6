﻿using Microsoft.Extensions.Options;

namespace Platform {
    public class QueryStringMiddleware {
        private RequestDelegate? next;
        public QueryStringMiddleware() {
            // do nothing
        }

        public QueryStringMiddleware(RequestDelegate nextDelegate) {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context) {
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true") {
                if (!context.Response.HasStarted) {
                    context.Response.ContentType = "text/plain";
                }
                await context.Response.WriteAsync("Class-based middleware\n");
            }
            if (next != null) {
                await next(context);
            }
        }
    }

    public class LocationMiddleware {
        private RequestDelegate next;
        private MessageOptions options;
        
        public LocationMiddleware(RequestDelegate nextDelegate, IOptions<MessageOptions> opts) {
            next = nextDelegate;
            options = opts.Value;
        }

        public async Task Invoke(HttpContext context) {
            if (context.Request.Path == "/location") {
                await context.Response.WriteAsync($"{options.CityName}, {options.CountryName}");
            } else {
                await next(context);
            }
        }
    }
}
