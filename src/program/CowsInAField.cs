namespace program;

public class CowsInAField
{
    public List<Cow> Cows { get; set; }
    public Dictionary<int, string> CowDictionary { get; set; }
    public int NumberOfCows => Cows.Count;
    public int SizeOfField { get; set; }

    public CowsInAField(List<Cow> cowList, int sizeOfField)
    {
        Cows = cowList;
        CowDictionary = new Dictionary<int, string>();
        for(int i=0; i<cowList.Count; i++)
        {
            CowDictionary.Add(i, $"{cowList[i].Xcoord},{cowList[i].Ycoord}");
        }

        SizeOfField = sizeOfField;
    }

    public int GetCowNeighbours()
    {
        int numberOfCows = GetNumberOfCows();
        int numberOfCowNeighbours = 0;
        for (int i = 0; i < numberOfCows; i++)
        {
            int x = GetXCoordinateForCow(i);
            int y = GetYCoordinateForCow(i);
            if (IsCowNeighbour(x, y))
                numberOfCowNeighbours++;
        }

        return numberOfCowNeighbours;
    }
    
    public bool IsCowNeighbour(int x, int y)
    {
        if (IsCowAtPosition($"{x+1},{y}"))
            return true;
        if (IsCowAtPosition($"{x-1},{y}"))
            return true;
        if (IsCowAtPosition($"{x},{y+1}"))
            return true;
        if (IsCowAtPosition($"{x},{y-1}"))
            return true;
        return false;
    }
    
    public bool IsCowAtPosition(string cowString)
    {
        if(CowDictionary.ContainsValue(cowString))
            return true;
        
        return false;
    }
    
    public int GetCowsInACorner()
    {
        int numberOfCowsInACorner = 0;
        int numberOfCows = GetNumberOfCows();

        if (numberOfCows == 1 && SizeOfField == 1)
            return 1;
        
        for (int i = 0; i < numberOfCows; i++)
        {
            int x = GetXCoordinateForCow(i);
            int y = GetYCoordinateForCow(i);
            if (x == 0 && y == 0)
                numberOfCowsInACorner++;
            else if (x==0 && y == SizeOfField-1)
            {
                numberOfCowsInACorner++;
            }
            else if (x== SizeOfField-1 && y == 0)
            {
                numberOfCowsInACorner++;
            }
            else if (x==SizeOfField-1 && y == SizeOfField-1)
            {
                numberOfCowsInACorner++;
            }
        }

        return numberOfCowsInACorner;
    }

    public int GetNumberOfCows()
    {
        return NumberOfCows;
    }
    
    public int GetXCoordinateForCow(int i)
    {
        return Cows[i].Xcoord;
    }

    public int GetYCoordinateForCow(int i)
    {
        return Cows[i].Ycoord;
    }
}

