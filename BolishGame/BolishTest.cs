using System;

namespace BolishGame
{
  static public class BolishTest
  {
    static private Game game;

    /// <summary>
    /// Executa todos os testes
    /// </summary>
    static public void Execute()
    {
      CanCreateGame();
      CanRoll();
      GutterGame();
      AllOnes();
      OneSpare();
    }

    #region Tests
    /// <summary>
    /// Testa se o jogo pode ser criado
    /// </summary>
    static private void CanCreateGame()
    {
      try
      {
        Game _game = new Game();
        game = _game;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    /// <summary>
    /// Testa se todas as rolagens estão executando
    /// </summary>
    static private void CanRoll()
    {
      try
      {
        for (int i = 0; i < 10; i++)
        {
          game.Roll(0);
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    /// <summary>
    /// Testa se a pontuação final de um jogo onde ocorreram 0 zeros, é nula
    /// </summary>
    static private void GutterGame()
    {
      try
      {
        game.Reset();
        RollMany(20, 0);

        if (game.Score() != 0)
        {
          throw new Exception(String.Concat(
            "Não passou pelo GutterGame, Score = ", game.Score()
          ));
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    /// <summary>
    /// Testa o jogo quando todas as rolagens são iguais a 1
    /// </summary>
    static private void AllOnes()
    {
      try
      {
        game.Reset();
        RollMany(20, 1);

        if (game.Score() != 20)
        {
          throw new Exception(String.Concat(
            "Não passou pelo AllOnes, Score = ", game.Score()
          ));
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    /// <summary>
    /// Teste o caso em que ocorre um Spare no primeiro frame
    /// </summary>
    static private void OneSpare()
    {
      try
      {
        game.Reset();
        game.Roll(5);
        game.Roll(5);
        game.Roll(3);
        RollMany(17, 0);

        if (game.Score() != 16)
        {
          throw new Exception(String.Concat(
            "Não passou pelo OneSpare, Score = ", game.Score(), " que é diferente de 16"
          ));
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    #endregion

    #region TestHelper
    /// <summary>
    /// Faz uma rolagem um número especificado de vezes com entrada fixa
    /// </summary>
    /// <param name="timesToRoll">Quantidade de rolagens</param>
    /// <param name="pinsKnockedDown">Entrada fixa</param>
    static private void RollMany(int timesToRoll, int pinsKnockedDown)
    {
      for (int i = 0; i < timesToRoll; i++)
      {
        game.Roll(pinsKnockedDown);
      }
    }
    #endregion
  }
}
