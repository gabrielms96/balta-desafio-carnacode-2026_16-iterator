using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Interfaces;

/// <summary>
/// Coleção de músicas que suporta múltiplos tipos de iteração (sequencial, shuffle, gênero, oldies).
/// Mantém a encapsulação: a estrutura interna nunca é exposta.
/// </summary>
public interface IPlaylistCollection : IIterableCollection<Song>
{
    IIterator<Song> CreateShuffleIterator();
    IIterator<Song> CreateGenreIterator(string genre);
    IIterator<Song> CreateOldiesIterator(int yearThreshold = 2000);
}
