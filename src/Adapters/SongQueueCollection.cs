using System.Collections.Generic;
using DesignPatternChallenge.Interfaces;
using DesignPatternChallenge.Iterators;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Adapters;

/// <summary>
/// Adapter: permite iterar sobre uma cópia da fila sem consumi-la (sem Dequeue).
/// Interface uniforme para Queue como IIterableCollection.
/// </summary>
public class SongQueueCollection : IIterableCollection<Song>
{
    private readonly Queue<Song> _queue;
    public string Name { get; } = "Fila de músicas";

    public SongQueueCollection(Queue<Song> queue)
    {
        _queue = queue ?? throw new ArgumentNullException(nameof(queue));
    }

    public IIterator<Song> CreateSequentialIterator()
    {
        var snapshot = _queue.ToArray();
        return new SequentialIterator(snapshot.ToList());
    }
}
