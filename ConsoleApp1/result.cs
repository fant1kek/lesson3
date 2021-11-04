namespace result
{
    class Result
    {
        public string GetResult(int playerMuve, int computerMuve, int numMoves)
        {
            int temp = numMoves / 2;
            if (playerMuve == computerMuve)
                return "DRAW";
            else if (playerMuve <= numMoves)
                if (computerMuve >= temp + 1)
                    if ((playerMuve >= computerMuve - temp) && (playerMuve < computerMuve))
                        return "You luse";
                    else
                        return "You win";
                else
                    if ((playerMuve <= computerMuve + temp) && (playerMuve > computerMuve))
                        return "You win";
                    else
                        return "You luse";
            return "";
        }
    }
}