using System;
using System.Linq;
using System.Text;

namespace BolishGame
{
  class Game
  {
    private int[] Rolls { get; set; }
    private int currentRollIndex { get; set; }

    /// <summary>
    /// Constrói os campos pela primeira vez
    /// </summary>
    public Game()
    {
      Reset();
    }

    #region Game operations
    /// <summary>
    /// Faz uma rolagem em um Frame
    /// </summary>
    /// <param name="pinsKnockedDown"></param>
    public void Roll(int pinsKnockedDown)
    {
      Rolls[currentRollIndex++] = pinsKnockedDown;
    }
    /// <summary>
    /// Faz uma rolagem um número especificado de vezes com entrada fixa
    /// </summary>
    /// <param name="timesToRoll">Quantidade de rolagens</param>
    /// <param name="pinsKnockedDown">Entrada fixa</param>
    public void RollMany(int timesToRoll, int pinsKnockedDown)
    {
      for (int i = 0; i < timesToRoll; i++)
      {
        Roll(pinsKnockedDown);
      }
    }
    /// <summary>
    /// Rola um Strike
    /// </summary>
    public void RollStrike()
    {
      Roll(10);
    }
    /// <summary>
    /// É chamado no final do jogo
    /// Atribui pontuação a cada um dos 10 frames
    /// </summary>
    /// <returns>Pontuação do jogador</returns>
    public int Score()
    {
      int score = 0;
      int firstTry = 0;
      for (int frameIndex = 0; frameIndex < 10; frameIndex++)
      {
        if (IsStrike(firstTry))
        {
          score += 10 + StrikeExtraPoints(firstTry);
          firstTry++;
        }
        else if (IsSpare(firstTry))
        {
          score += 10 + SpareExtraPoints(firstTry);
          firstTry += 2;
        }
        else
        {
          score += OrdinaryPoints(firstTry);
          firstTry += 2;
        }
      }
      return score;
    }
    /// <summary>
    /// Reseta o jogo
    /// </summary>
    public void Reset()
    {
      Rolls = new int[21];
      currentRollIndex = 0;
    }
    /// <summary>
    /// Mostra no console o resultado do jogo
    /// </summary>
    public void Result()
    {
      StringBuilder output = new StringBuilder();
      for (int i = 0; i < Rolls.Count(); i++)
      {
        if (i == 0)
        {
          output.Append(String.Concat("[", Rolls[i], ", "));
        }
        else if (0 < i && i < Rolls.Count() - 1)
        {
          output.Append(String.Concat(Rolls[i], ", "));
        }
        else
        {
          output.Append(String.Concat(Rolls[i], "] Score = ", Score()));
        }
      }
      Console.WriteLine(output.ToString());
    }
    #endregion

    #region Utility tools
    /// <summary>
    /// Verifica se houve um Spare no atual frame
    /// </summary>
    /// <param name="firstTry">Índice da primeira rolagem no atual frame</param>
    /// <returns>true se houve spare, false caso contrário</returns>
    private bool IsSpare(int firstTry)
    {
      return Rolls[firstTry] + Rolls[firstTry + 1] == 10;
    }
    /// <summary>
    /// Verifica se houve um Strike no atual frame
    /// </summary>
    /// <param name="firstTry">Índice da primeira rolagem no atual frame</param>
    /// <returns>true se houve Strike, false caso contrário</returns>
    private bool IsStrike(int firstTry)
    {
      return Rolls[firstTry] == 10;
    }
    /// <summary>
    /// Calcula os pontos base que são ganhos em todos os frames
    /// </summary>
    /// <param name="firstTry">Índice da primeira rolagem no atual frame</param>
    /// <returns>Pontos base ganhos em todos os frames</returns>
    private int OrdinaryPoints(int firstTry)
    {
      return Rolls[firstTry] + Rolls[firstTry + 1];
    }
    /// <summary>
    /// Calcula os pontos extras provenientes de Spares
    /// </summary>
    /// <param name="firstTry">Índice da primeira rolagem no atual frame</param>
    /// <returns>Pontos extras provenientes de spares</returns>
    private int SpareExtraPoints(int firstTry)
    {
      return Rolls[firstTry + 2];
    }
    /// <summary>
    /// Calcula os pontos extras provenientes de Strikes
    /// </summary>
    /// <param name="firstTry">Índice da primeira rolagem no atual frame</param>
    /// <returns>Pontos extras provenientes de um strike</returns>
    private int StrikeExtraPoints(int firstTry)
    {
      return Rolls[firstTry + 1] + Rolls[firstTry + 2];
    }
    #endregion
  }
}
