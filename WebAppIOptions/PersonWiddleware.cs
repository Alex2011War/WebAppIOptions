using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace WebAppIOptions
{
    public class PersonWiddleware
    {
        private readonly RequestDelegate next;
        public Person Person { get; }

        public PersonWiddleware(RequestDelegate _next, IOptions<Person> options)
        {
            next = _next;
            Person = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"<p>Name:{Person?.Name}</p>");
            stringBuilder.Append($"<p>Age:{Person.Age}</p>");
            stringBuilder.Append($"<p>Age:{Person.Company.Title}</p>");
            stringBuilder.Append("<h3>Languages</h3><ul>");
            foreach (var lang in Person.Languages)
            
                stringBuilder.Append($"<li>{lang}</li>");
                stringBuilder.Append("</ul>");
            

            await context.Response.WriteAsync(stringBuilder.ToString());

        }
    }
}
