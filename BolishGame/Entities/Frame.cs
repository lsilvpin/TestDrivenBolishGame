namespace BolishGame.Entities
{
  class Frame
  {
    private int FirstRoll { get; set; }
    private int SecondRoll { get; set; }

    /// <summary>
    /// Calcula a pontuação de uma instância deste Frame
    /// Faz um loop pelas Rolls, porém, precisa acessar as Rolls vizinhas em casos especiais
    /// </summary>
    /// <returns>Pontuação da instância</returns>
    public int Score()
    {
      return FirstRoll + SecondRoll;
    }
  }
}
