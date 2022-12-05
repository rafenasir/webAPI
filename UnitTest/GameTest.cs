using Xunit;
using webAPI.Services;
using System.Collections.Generic;
using webAPI.Parameters;

namespace UnitTest
{
    public class GameTest
    {
        GameService gameService = new GameService();
        [Fact]
        public void Opened_box_must_be_Goat()
        {
            ListItems item1 = new ListItems
            {
                boxValue = "Goat",
                indexNumber = 1,
            };
            ListItems item2 = new ListItems
            {
                boxValue = "Car",
                indexNumber = 2,
            };
            ListItems item3 = new ListItems
            {
                boxValue = "Goat",
                indexNumber = 3,
            };

            List<ListItems> displayArray = new List<ListItems> { item1, item2, item3};
            int selector = 2;

            ListItems openDoor = gameService.openDoor(displayArray, selector);

            Assert.Equal("Goat", openDoor.boxValue);
        }
    }
}