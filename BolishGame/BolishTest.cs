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
      OneStrike();
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
        game.RollMany(20, 0);

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
        game.RollMany(20, 1);

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
        game.RollMany(17, 0);

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
    /// <summary>
    /// Testa o caso em que ocorre um Strike
    /// </summary>
    static private void OneStrike()
    {
      try
      {
        game.Reset();
        game.Roll(10);
        game.Roll(0);
        game.Roll(3);
        game.Roll(4);
        game.RollMany(16, 0);

        if (game.Score() != 24)
        {
          throw new Exception(String.Concat(
            "Não passou pelo OneStrike, Score = ", game.Score(), " ao invés de 24"
          ));
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    #endregion
  }
}
