using BolishGame.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BolishGame
{
  class Game
  {
    private List<int> Rolls { get; set; }
    private List<Frame> Frames { get; set; }

    /// <summary>
    /// Constrói os campos pela primeira vez
    /// </summary>
    public Game()
    {
      Rolls = new List<int>();
      Frames = new List<Frame>();
    }

    /// <summary>
    /// Faz uma rolagem em um Frame
    /// </summary>
    /// <param name="pinsKnockedDown"></param>
    public void Roll (int pinsKnockedDown)
    {
      Rolls.Add(pinsKnockedDown);
    }
    /// <summary>
    /// É chamado no final do jogo
    /// Atribui pontuação a cada um dos 10 frames
    /// </summary>
    /// <returns>Pontuação do jogador</returns>
    public int Score()
    {
      int sparePoints = 0;
      for (int i = 0; i < 20; i += 2)
      {
        if (Rolls[i+1] + Rolls[i] == 10)
        {
          sparePoints += Rolls[i + 2];
        }
      }
      return Rolls.Sum(roll => roll) + sparePoints;
    }
    /// <summary>
    /// Reseta o jogo
    /// </summary>
    public void Reset()
    {
      Rolls = null;
      Rolls = new List<int>();
    }
  }
}
