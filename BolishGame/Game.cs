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
      return Rolls.Sum(roll => roll);
    }
  }
}
