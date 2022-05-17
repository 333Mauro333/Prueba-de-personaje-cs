using System;
using System.Collections.Generic;

using Mgtv_Library;


namespace MgtvPlayerTestCs
{
    class OptionsPanel
    {
        List<string> optionsList;
        Vector2i displayPosition;

        string selectedLeftArrow;
        string selectedRightArrow;

        int actualOption;
        bool active;



        public OptionsPanel(int x, int y, bool active = true)
        {
            optionsList = new List<string>();
            displayPosition.x = x;
            displayPosition.y = y;

            selectedLeftArrow = " <--";
            selectedRightArrow = "--> ";

            actualOption = 1;
            this.active = active;
        }


        public int ActualOption
        {
            get { return actualOption; }
        }


        public void Update(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
            {
                ChangeOption(OptionChangeType.PREVIOUS);
            }
            else if (key == ConsoleKey.DownArrow)
            {
                ChangeOption(OptionChangeType.NEXT);
            }
        }

        public bool IsActive()
        {
            return active;
        }

        public void Activate()
        {
            active = true;
            WriteOptions();
        }
        public void Deactivate()
        {
            active = false;
            EraseOptions();
        }

        public void AddOption(string option)
        {
            optionsList.Add(option);

            if (optionsList.Count == 1)
            {
                displayPosition.x -= optionsList[0].Length / 2 + 4;
            }
        }
        void WriteOptions()
        {
            C.GoToCoordinates(displayPosition.x, displayPosition.y);

            for (int i = 0; i < optionsList.Count; i++)
            {
                C.GoToCoordinates(displayPosition.x - (optionsList[i].Length / 2 - 4), displayPosition.y + i * 2);

                if (actualOption == i + 1)
                {
                    C.WriteInColor(selectedRightArrow + optionsList[i] + selectedLeftArrow, ConsoleColor.Yellow);
                }
                else
                {
                    Console.Write("    " + optionsList[i] + "    ");
                }
            }
        }
        void EraseOptions()
        {
            C.GoToCoordinates(displayPosition.x, displayPosition.y);

            for (int i = 0; i < optionsList.Count; i++)
            {
                C.GoToCoordinates(displayPosition.x - (optionsList[i].Length / 2 - 4), displayPosition.y + i * 2);

                Console.Write("    ");

                for (int j = 0; j < optionsList[i].Length; j++)
                {
                    Console.Write(" ");
                }

                Console.Write("    ");
            }
        }


        void ChangeOption(OptionChangeType oct)
        {
            switch (oct)
            {
                case OptionChangeType.PREVIOUS:
                    actualOption = (actualOption <= 1) ? optionsList.Count : actualOption - 1;
                    break;

                case OptionChangeType.NEXT:
                    actualOption = (actualOption >= optionsList.Count) ? 1 : actualOption + 1;
                    break;
            }

            if (active)
            {
                WriteOptions();
            }
        }
    }
}
