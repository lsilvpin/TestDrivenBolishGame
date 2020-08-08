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
        for (int i = 0; i<20; i++)
        {
          game.Roll(0);
        }

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
        for (int i = 0; i < 20; i++)
        {
          game.Roll(1);
        }

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
    #endregion
  }
}
