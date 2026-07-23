namespace PEMS.AI.Interfaces;

public interface IOllamaService
{
    Task<string> GenerateAsync(string prompt);
}