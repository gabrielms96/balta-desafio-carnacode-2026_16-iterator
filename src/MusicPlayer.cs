using DesignPatternChallenge.Interfaces;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge;

/// <summary>
/// Cliente do padrão Iterator: toca músicas usando APENAS a interface IIterator.
/// Não conhece List, Array, Queue nem a estrutura interna das coleções.
/// Múltiplas iterações simultâneas são independentes (cada uma tem seu próprio iterador).
/// </summary>
public class MusicPlayer
{
    /// <summary>Toca todas as músicas do iterador, na ordem que o iterador define.</summary>
    public void Play(IIterator<Song> iterator, string collectionName, string? modeDescription = null)
    {
        var title = string.IsNullOrEmpty(modeDescription)
            ? $"Tocando {collectionName}"
            : $"Tocando {collectionName} ({modeDescription})";
        Console.WriteLine($"\n=== {title} ===");

        var position = 1;
        while (iterator.MoveNext())
        {
            Console.WriteLine($"{position}. {iterator.Current}");
            position++;
        }
    }
}
