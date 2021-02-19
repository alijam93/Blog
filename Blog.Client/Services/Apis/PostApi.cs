using Blog.Client.Utils.Pagination;
using Blog.Shared.DTOs;
using Blog.Shared.Models;
using Blog.Shared.Providers.Pagination;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blog.Client.Services.Apis
{
    public class PostApi
    {
        string url;
        private readonly HttpClient _http;

        public PostApi(HttpClient http)
        {
            _http = http;
        }

        public async Task<PagingResponse<PostDTO>> GetPostsByTag(PostParameters postParameters, string name)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = postParameters.PageNumber.ToString()
            };

            url = $"api/posts/{name}";

            var response = await _http.GetAsync(QueryHelpers.AddQueryString(url, queryStringParam));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<PostDTO>
            {
                Items = JsonSerializer.Deserialize<List<PostDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                Paging = JsonSerializer.Deserialize<Paging>(response.Headers.GetValues("X-Pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            };

            return pagingResponse;
        }

        public async Task<PagingResponse<PostDTO>> GetPosts(PostParameters postParameters, string name, int tagId)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = postParameters.PageNumber.ToString()
            };
            if (tagId > 0)
            {
                url = $"api/posts/{name}";
            }
            else
            {
                url = "api/posts";
            }

            var response = await _http.GetAsync(QueryHelpers.AddQueryString(url, queryStringParam));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<PostDTO>
            {
                Items = JsonSerializer.Deserialize<List<PostDTO>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                Paging = JsonSerializer.Deserialize<Paging>(response.Headers.GetValues("X-Pagination").First(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
            };

            return pagingResponse;
        }

        public async Task<PostDTO> GetPostsByById(int id, string slug)
        {
            return await _http.GetFromJsonAsync<PostDTO>($"api/posts/{id}/{slug}");
        }
    }
}
