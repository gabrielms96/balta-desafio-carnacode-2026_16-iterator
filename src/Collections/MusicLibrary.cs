using DesignPatternChallenge.Interfaces;
using DesignPatternChallenge.Iterators;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Collections;

/// <summary>
/// Biblioteca com estrutura interna complexa (por gênero e artista). NUNCA expõe
/// dicionários; a iteração é feita apenas via iteradores.
/// </summary>
public class MusicLibrary : IIterableCollection<Song>
{
    public string Name { get; set; } = "Biblioteca";
    private readonly Dictionary<string, List<Song>> _songsByGenre = new();
    private readonly Dictionary<string, List<Song>> _songsByArtist = new();

    public void AddSong(Song song)
    {
        if (!_songsByGenre.ContainsKey(song.Genre))
            _songsByGenre[song.Genre] = new List<Song>();
        _songsByGenre[song.Genre].Add(song);

        if (!_songsByArtist.ContainsKey(song.Artist))
            _songsByArtist[song.Artist] = new List<Song>();
        _songsByArtist[song.Artist].Add(song);
    }

    /// <summary>Iteração sobre todas as músicas (únicas) sem expor a estrutura interna.</summary>
    public IIterator<Song> CreateSequentialIterator()
    {
        var all = _songsByGenre.Values.SelectMany(list => list).Distinct().ToList();
        return new SequentialIterator(all);
    }
}
