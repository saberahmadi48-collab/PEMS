using System.Net.Http.Json;
using PEMS.AI.Interfaces;
using PEMS.AI.Models;

namespace PEMS.AI.Services;

public class OllamaService : IOllamaService
{
    private readonly HttpClient _httpClient;

    public OllamaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<string> GenerateAsync(string prompt)
    {
        var request = new OllamaRequest
        {
            Prompt = prompt
        };


        var response = await _httpClient.PostAsJsonAsync(
            "api/generate",
            request
        );


        response.EnsureSuccessStatusCode();


        var result =
            await response.Content.ReadFromJsonAsync<OllamaResponse>();


        return result?.Response ?? "";
    }
}