namespace program;

public class CowsInAField
{
    public List<Cow> Cows { get; set; }
    public Dictionary<int, Cow> CowDictionary { get; set; }
    public int NumberOfCows => Cows.Count;
    public int SizeOfField { get; set; }

    public CowsInAField()
    {
        Cows = new List<Cow>() {new Cow(0,0)};
        SizeOfField = 1;
    }
    
    public CowsInAField(List<Cow> cowList, int sizeOfField)
    {
        Cows = cowList;
        CowDictionary = new Dictionary<int, Cow>();
        for(int i=0; i<cowList.Count; i++)
        {
            CowDictionary.Add(i, cowList[i]);
        }

        SizeOfField = sizeOfField;
    }

    public void AddCow(Cow cow)
    {
        Cows.Add(cow);
    }

    public List<Tuple<int, int>> GetCowCordinatesList()
    {
        List<Tuple<int, int>> cowCoordinates = new List<Tuple<int, int>>();
        int numberOfCows = GetNumberOfCows();
        for (int i = 0; i < numberOfCows; i++)
        {
            int x = GetXCoordinateForCow(i);
            int y = GetYCoordinateForCow(i);
            cowCoordinates.Add(new Tuple<int, int>(x, y));
        }

        foreach (var item in cowCoordinates)
            Console.WriteLine("x: " + item.Item1 + " y: " + item.Item2);

        return cowCoordinates;
    }
    
    public Dictionary<int, Cow> GetCowCordinatesDictionary()
    {
        Dictionary<int, Cow> cowCoordinates = new Dictionary<int, Cow>();
        int numberOfCows = GetNumberOfCows();
        for (int i = 0; i < numberOfCows; i++)
        {
            int x = GetXCoordinateForCow(i);
            int y = GetYCoordinateForCow(i);
            cowCoordinates.Add(i, new Cow(x, y));
        }

        return cowCoordinates;
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
        if (IsCowAtPosition(new Cow(x + 1, y)))
            return true;
        if (IsCowAtPosition(new Cow(x - 1, y)))
            return true;
        if (IsCowAtPosition(new Cow(x, y + 1)))
            return true;
        if (IsCowAtPosition(new Cow(x, y - 1)))
            return true;
        return false;
    }
    
    public bool IsCowAtPosition(Cow cow)
    {
        if(CowDictionary.ContainsValue(cow))
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

