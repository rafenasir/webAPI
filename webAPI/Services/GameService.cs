using webAPI.Interface;
using webAPI.Parameters;

namespace webAPI.Services
{
    public class GameService : IGameService
    {
        public string GetResultAsync(RequestParamters request)
        {
            if (request.numberOfGames >= 1)
            {
                int win = 0;
                int lose = 0;
                for (int i = 1; i <= request.numberOfGames; i++)
                {
                    string winOrLose = GetFinalResult(request.wantSwitch);
                    if (winOrLose == "You Win")
                    {
                        win++;
                    }
                    else if (winOrLose == "You Lose")
                    {
                        lose++;
                    }
                }
                if (request.wantSwitch == "Yes")
                {
                    if (lose > win)
                    {
                        return $"You won {win} Times and you Lost {lose} Times, So unfortunately you lost more than you Won";
                    }
                    else
                    {
                        return $"You won {win} Times and you Lost {lose} Times. As you Opted to Switch This shows you won more than you lose.";
                    }
                }
                else
                {
                    if (lose > win)
                    {
                        return $"You won {win} Times and you Lost {lose} Times. So unfortunately you lost more than you Won";
                    }
                    else
                    {
                        return $"You won {win} Times and you Lost {lose} Times. Though you opted not to switch still you won more than you lose.";
                    }
                }
            }
            else
            {
                return "Minimum Number of games is atleast 1. Please try to play 1 or more game to prove";
            }
        }


        public string GetFinalResult(string wantSwitch)
        {
            var displayArray = CreateDisplayArray();

            for (int i = 0; i < displayArray.Count; i++)
            {
                Console.WriteLine($"First Box Value is {displayArray[i].boxValue} & the Index Number is -- {displayArray[i].indexNumber}");
            };

            Random rndm = new Random();
            int selector = rndm.Next(displayArray.Count);
            //This will be the door Selector by the Player
            Console.WriteLine($"The Selector is --- {selector}");

            var opener = openDoor(displayArray, selector);

            //Open Door Number has been Selected.
            Console.WriteLine($"Door Opener Array contains {opener.boxValue} & on IndexNumber -- {opener.indexNumber}");

            string finalResultPrint = finalResult(displayArray, opener, selector, wantSwitch);

            return finalResultPrint;
        }

        string finalResult(List<ListItems> displayArray, ListItems opener, int selector, string wantSwitch)
        {
            string finalResult = string.Empty;
            int finalSelector = selector;



            Console.WriteLine($"Selected Box Contain -- {displayArray[selector].boxValue}");
            if (wantSwitch == "Yes")
            {
                for (int i = 0; i < displayArray.Count; i++)
                {
                    if (displayArray[i].indexNumber != selector && displayArray[i].indexNumber != opener.indexNumber)
                    {
                        finalSelector = displayArray[i].indexNumber;
                    }

                }

            }
            if (displayArray[finalSelector].boxValue == "Car")
            {
                finalResult = "You Win";
            }
            else
            {
                finalResult = "You Lose";
            }

            Console.WriteLine($"Your Final Result it -- {finalResult}");

            return finalResult;
        }

        public ListItems openDoor(List<ListItems> list, int selectorNumber)
        {
            List<ListItems> newList = new List<ListItems>();
            ListItems openDoor = new ListItems();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].indexNumber != selectorNumber && list[i].boxValue != "Car")
                {
                    newList.Add(list[i]);
                }
            }
            if (newList.Count > 1)
            {
                Random rndm = new Random();
                int selector = rndm.Next(newList.Count);
                openDoor = newList[selector];
            }
            openDoor = newList[0];

            return openDoor;
        }

        private List<ListItems> CreateDisplayArray()
        {

            List<ListItems> options = new List<ListItems>();

            for (int i = 0; i <= 2; i++)
            {
                options.Add(new ListItems { boxValue = "Goat", indexNumber = i });
            }
            var rndm = new Random();
            var randomNumber = rndm.Next(options.Count);
            options[randomNumber].boxValue = "Car";

            return options;
        }
    }
}


