using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DotPalette{Pink,Orange,Red,Blue,Green,Purple,None,All}

public static class ColorSchema {

	#region color

	private static Color pink = new Color(255f/255f,159f/255f,243f/255f);
  private static Color orange = new Color(254f/255f,202f/255f,87f/255f);
  private static Color red = new Color(255f/255f,107f/255f,107f/255f);
  private static Color blue = new Color(84f/255f,160f/255f,255f/255f);
  private static Color green = new Color(29f/255f,209f/255f,161f/255f);
  private static Color purple = new Color(95f/255f,39f/255f,205f/255f);

  private static Color error = new Color(0,0,0);

	#endregion

  // https://flatuicolors.com/palette/ca
  public static Color GetColor(DotPalette color){
    if(color==DotPalette.Pink)
      return pink;
    if(color==DotPalette.Orange)
      return orange;
    if(color==DotPalette.Red)
      return red;
    if(color==DotPalette.Blue)
      return blue;
    if(color==DotPalette.Green)
      return green;
    if(color==DotPalette.Purple)
      return purple;
    return error;
  }
}
