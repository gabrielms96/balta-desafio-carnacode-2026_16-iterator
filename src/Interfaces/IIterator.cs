namespace DesignPatternChallenge.Interfaces;

/// <summary>
/// Interface do padrão Iterator: define a forma uniforme de percorrer uma coleção
/// sem expor sua representação interna.
/// </summary>
public interface IIterator<out T>
{
    /// <summary>Elemento atual da iteração.</summary>
    T Current { get; }

    /// <summary>Avança para o próximo elemento. Retorna false quando não há mais elementos.</summary>
    bool MoveNext();

    /// <summary>Reinicia a iteração para o início.</summary>
    void Reset();
}
