using System;


namespace MgtvPlayerTestCs
{
    abstract class Screen : Scene
    {
        protected int actualOption;


        public Screen(int actualOption)
        {
            this.actualOption = actualOption;
        }


        protected void ChangeOption(OptionChangeType option, int maxOption)
        {
            switch (option)
            {
                case OptionChangeType.PREVIOUS:
                    actualOption = (actualOption > 1) ? actualOption - 1 : maxOption;
                    break;

                case OptionChangeType.NEXT:
                    actualOption = (actualOption < maxOption) ? actualOption + 1 : 1;
                    break;
            }
        }
        protected abstract void EnterOption();
    }
}
