namespace Jogo18Ghosts
{
    public enum State {
        Undecided,

        P1,
        P2,

        YellowCorridor = 'y',
        BlueCorridor = 'b',
        RedCorridor = 'r',

        YellowPortal = 'Y',
        BluePortal = 'B',
        RedPortal = 'R',

        Mirror = 'M',

        RedGhostsP1 = 'a',
        BlueGhostsP1 = 'b',
        YellowGhostsP1 = 'c',

        RedGhostsP2 = 'A',
        BlueGhostsP2 = 'B',
        YellowGhostsP2 = 'C'
    };
}