using AngleSharp;

using Newtonsoft.Json;

using Study.CrawlingTest.Models;

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Study.CrawlingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. 크롤링이란?
            //http의 request response 를 구현하여?? 필요한 데이터를 가져오는 기술?

            //2. c# 권장하는 구현은 HttpClient 로 구현하는 것이나, 
            //HttpWebRequest가 기능이 훨씬 다양한 접근이 가능하다(?)

            //3. Python beautiful soup 4과 같은 라이브러리가 지원되어 css selector 와 같은 형태로
            //html 을 가공하기가 좋으나,
            //c# 의 경우 제일 유명한 httpagility의 경우 xml 처럼 xpath 기반으로 동작하여,
            //약간의 난이도가 있다
            //beautiful soup 4과 같은 비슷한 라이브러리가 있었는데 지금은 더이상 개발되지 않고,
            //비슷한 기능을 하는 anglesharp nuget 패키지가 있다

            CookieContainer cookieContainer = new();
            HttpClientHandler httpClientHandler = new();
            httpClientHandler.CookieContainer = cookieContainer;

            HttpClient client = new(httpClientHandler);
            client.DefaultRequestHeaders.Add("Accept-Language", "ko-KR,en-US");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko");

            var request = new HttpRequestMessage();
            request.Method = HttpMethod.Get;

            //1. Html 페이지 크롤링 
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));

            /*
            //var data = await content.ReadAsStringAsync();
            request.RequestUri = new Uri("https://weather.naver.com/today/09560101");
            //request.Content = content;
            var task = Task.Run(async () =>
            {
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
                //response.EnsureSuccessStatusCode(); //200 성공이 아니면 Exception을 발생시킴

                string responseHtml = await response.Content.ReadAsStringAsync();

                var config = Configuration.Default.WithDefaultLoader();
                var context = BrowsingContext.New(config);
                var document = await context.OpenAsync(request => request.Content(responseHtml));

                var now_tempNode = document.QuerySelector("div.today_weather div.weather_area strong.current");

                var now_tempTextNode = now_tempNode.ChildNodes.FirstOrDefault(node => node.NodeType == AngleSharp.Dom.NodeType.Text);

                if (now_tempTextNode != null)
                {
                    Console.WriteLine(now_tempTextNode.TextContent);
                }
            });
            */

            //2. Web API 사용
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            request.RequestUri = new Uri("https://jsonplaceholder.typicode.com/todos/1");
            //request.Content = content;
            var task = Task.Run(async () =>
            {
                var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
                //response.EnsureSuccessStatusCode(); //200 성공이 아니면 Exception을 발생시킴

                string responseHtml = await response.Content.ReadAsStringAsync();

                //System.Text.Json --> Dotnet Core 3.0 부터 지원되고, UTF-8 기준으로 파싱하고,
                //좀 더 엄격한 규칙으로 진행되므로 속도가 빠르다.
                //하지만 엄격한 규칙으로 Json Text 에서 객체로 변환시 오류나 null이 반환될 가능성이 높다
                //한가지 예를 들면 { num: "1" } 이걸 int 로 변환시 오류 또는 null을 반환한다.
                //또한 대소문자도 구분한다
                //var model = System.Text.Json.JsonSerializer.Deserialize<WebApiSampleModel>(responseHtml);

                //하지만, newtonsoft.Json 은 UTF-16 으로 파싱하므로 성능이 약간 (ms단위)로 떨어지지만
                //좀 더 느슨한 규칙으로 변환에 대한 접근성?이 더 좋다.
                //대소문자를 구분하지 않는다
                //그래서 나는 newtonsoft를 선호한다.

                var model = JsonConvert.DeserializeObject<WebApiSampleModel>(responseHtml);

                model.Title = "하하하하핳ㅎ";

                string jsonText = JsonConvert.SerializeObject(model);

                Console.WriteLine(jsonText);
            });
            
            Task.WaitAll(task);
        }
    }
}
