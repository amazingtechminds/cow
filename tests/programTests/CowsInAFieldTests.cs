using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using program;

namespace programTests;

[TestClass]
public class CowsInAFieldTests
{
    [DataRow(2, 5)]
    [DataRow(3, 5)]
    [TestMethod]
    public void GetCorrectNumbersOfCows(int cowsAddedToList, int sizeOfField)
    {
        // Arrange
        var cows = new List<Cow>();
        for (int i = 0; i < cowsAddedToList; i++)
        {
            cows.Add(new Cow(i,i));
        }
        CowsInAField cowsInAField = new CowsInAField(cows, sizeOfField);

        // Act
        var result = cowsInAField.GetNumberOfCows();

        // Assert
        Assert.AreEqual(cowsAddedToList, result);
    }

    [TestMethod]
    public void GetCorrectNumbersOfCowsInACornerWithOneInEachCorner()
    {
        // Arrange
        var cows = new List<Cow>();
        cows.Add(new Cow(0, 0));
        cows.Add(new Cow(4, 0));
        cows.Add(new Cow(0, 4));
        cows.Add(new Cow(4, 4));

        CowsInAField cowsInAField = new CowsInAField(cows, 5);

        // Act
        var result = cowsInAField.GetCowsInACorner();

        // Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void GetCorrectNumbersOfCowsInACornerTwoCowsInACorner()
    {
        // Arrange
        var cows = new List<Cow>();
        cows.Add(new Cow(3, 3));
        cows.Add(new Cow(2, 2));
        cows.Add(new Cow(0, 4));
        cows.Add(new Cow(4, 4));

        CowsInAField cowsInAField = new CowsInAField(cows, 5);

        // Act
        var result = cowsInAField.GetCowsInACorner();

        // Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void GetZeroNeighboursOfEmptyField()
    {
        // Arrange
        var cows = new List<Cow>();

        CowsInAField cowsInAField = new CowsInAField(cows, 7);

        // Act
        var result = cowsInAField.GetCowNeighbours();

        // Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void IsCowInInField()
    {
        // Arrange
        var cows = new List<Cow>();
        cows.Add(new Cow(3, 3));

        CowsInAField cowsInAField = new CowsInAField(cows, 7);

        // Act
        var result = cowsInAField.IsCowAtPosition("3,3");

        // Assert
        Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void GetXNeighboursInCowField()
    {
        // Arrange
        var cows = new List<Cow>();
        cows.Add(new Cow(5, 0));
        cows.Add(new Cow(6, 0));
        cows.Add(new Cow(0, 2));
        cows.Add(new Cow(1, 2));
        cows.Add(new Cow(2, 5));
        cows.Add(new Cow(3, 5));

        CowsInAField cowsInAField = new CowsInAField(cows, 7);

        // Act
        var result = cowsInAField.GetCowNeighbours();

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void GetYNeighboursInCowField()
    {
        // Arrange
        var cows = new List<Cow>();
        cows.Add(new Cow(6, 1));
        cows.Add(new Cow(1, 2));
        cows.Add(new Cow(6, 2));
        cows.Add(new Cow(1, 3));
        cows.Add(new Cow(5, 6));

        CowsInAField cowsInAField = new CowsInAField(cows, 7);

        // Act
        var result = cowsInAField.GetCowNeighbours();

        // Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void GetXYNeighbourfInCowField()
    {
        // Arrange
        var cows = new List<Cow>();
        cows.Add(new Cow(5, 0));
        cows.Add(new Cow(6, 0));
        cows.Add(new Cow(6, 1));
        cows.Add(new Cow(0, 2));
        cows.Add(new Cow(1, 2));
        cows.Add(new Cow(6, 2));
        cows.Add(new Cow(1, 3));
        cows.Add(new Cow(2, 5));
        cows.Add(new Cow(3, 5));
        cows.Add(new Cow(5, 6));

        CowsInAField cowsInAField = new CowsInAField(cows, 7);

        // Act
        var result = cowsInAField.GetCowNeighbours();

        // Assert
        Assert.AreEqual(9, result);
    }

    [DataRow(7)]
    [DataRow(100)]
    [TestMethod]
    public void GetNeighboursOfFullCowFieldOfSize(int size)
    {
        // Arrange
        var cows = new List<Cow>();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                cows.Add(new Cow(i, j));
            }
        }
        CowsInAField cowsInAField = new CowsInAField(cows, 7);

        // Act
        var result = cowsInAField.GetCowNeighbours();

        // Assert
        Assert.AreEqual((size*size), result);
    }
    
    [DataRow(7)]
    [DataRow(100)]
    [TestMethod]
    public void GetNeighboursInChessBoardPatternCowFieldOfSize(int size)
    {
        // Arrange
        var cows = new List<Cow>();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if((i+j)%2 == 0)
                {
                    cows.Add(new Cow(i, j));
                }
            }
        }
        CowsInAField cowsInAField = new CowsInAField(cows, 7);

        // Act
        var result = cowsInAField.GetCowNeighbours();

        // Assert
        Assert.AreEqual(0, result);
    }
}
