using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Constants {
    public const int UNKNOWN_NUMBER = -99;
    public const int EXPERT_WIDTH = 30;
    public const int EXPERT_HEIGHT = 16;
    public const int EXPERT_NUMBER_OF_MINES = 99;
    public const int TOTAL_SAFE_SPACES = EXPERT_WIDTH * EXPERT_HEIGHT - EXPERT_NUMBER_OF_MINES;
}

public enum TileType {
    COVERED,
    COMPRESSED,
    UNCOVERED,
    FLAGGED,
    FALSE_FLAG,
    MINE
}
