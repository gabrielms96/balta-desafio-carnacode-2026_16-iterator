using System.Collections.Generic;
using DesignPatternChallenge;
using DesignPatternChallenge.Adapters;
using DesignPatternChallenge.Collections;
using DesignPatternChallenge.Models;

Console.WriteLine("=== Sistema de Playlist (Design Pattern Iterator) ===\n");

var playlist = new Playlist("Minhas Favoritas");
playlist.AddSong(new Song("Bohemian Rhapsody", "Queen", "Rock", 354, 1975));
playlist.AddSong(new Song("Imagine", "John Lennon", "Pop", 183, 1971));
playlist.AddSong(new Song("Smells Like Teen Spirit", "Nirvana", "Rock", 301, 1991));
playlist.AddSong(new Song("Billie Jean", "Michael Jackson", "Pop", 294, 1982));
playlist.AddSong(new Song("Hotel California", "Eagles", "Rock", 391, 1976));
playlist.AddSong(new Song("Sweet Child O' Mine", "Guns N' Roses", "Rock", 356, 1987));

var player = new MusicPlayer();

// Cliente usa apenas iteradores – não acessa lista nem estrutura interna
player.Play(playlist.CreateSequentialIterator(), playlist.Name, "Sequencial");
player.Play(playlist.CreateShuffleIterator(), playlist.Name, "Aleatório");
player.Play(playlist.CreateGenreIterator("Rock"), playlist.Name, "Gênero: Rock");
player.Play(playlist.CreateOldiesIterator(), playlist.Name, "Antigas (ano < 2000)");

// Interface uniforme para outras coleções (Array e Queue)
var arraySongs = new[] {
    new Song("Song A", "Artist A", "Pop", 200, 2020),
    new Song("Song B", "Artist B", "Rock", 180, 2019),
};
var arrayCollection = new SongArrayCollection(arraySongs);
player.Play(arrayCollection.CreateSequentialIterator(), arrayCollection.Name);

var queue = new Queue<Song>();
queue.Enqueue(new Song("First", "Band", "Jazz", 300, 2021));
queue.Enqueue(new Song("Second", "Band", "Jazz", 250, 2021));
var queueCollection = new SongQueueCollection(queue);
player.Play(queueCollection.CreateSequentialIterator(), queueCollection.Name);

// Biblioteca: iteração sem expor dicionários internos
var library = new MusicLibrary { Name = "Minha Biblioteca" };
library.AddSong(new Song("Lib Song 1", "Artist X", "Electronic", 240, 2022));
library.AddSong(new Song("Lib Song 2", "Artist Y", "Electronic", 200, 2023));
player.Play(library.CreateSequentialIterator(), library.Name);

Console.WriteLine("\n=== Benefícios do Padrão Iterator ===");
Console.WriteLine("✓ Estrutura interna das coleções não é exposta");
Console.WriteLine("✓ Uma única forma de percorrer: iterator.MoveNext() + Current");
Console.WriteLine("✓ Cliente independe do tipo (List, Array, Queue, Library)");
Console.WriteLine("✓ Múltiplas iterações simultâneas (cada uma com seu iterador)");
Console.WriteLine("✓ Iteradores personalizados (sequencial, shuffle, filtros)");
Console.WriteLine("✓ Possível pausar/retomar trocando de iterador ou chamando Reset()");
