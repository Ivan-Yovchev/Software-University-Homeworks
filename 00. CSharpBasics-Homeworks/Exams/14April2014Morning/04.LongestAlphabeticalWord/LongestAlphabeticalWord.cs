using System;
class LongestAlphabeticalWord
{
    static void Main(string[] args)
    {
        string word = Console.ReadLine();
        int size = int.Parse(Console.ReadLine());

        if (size == 1)
        {
            Console.WriteLine(word[0]);
        }
        else
        {
            char[] wordCharachters = word.ToCharArray();
            int place = 0;

            char[,] field = new char[size, size];

            // fill field
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    field[i, j] = wordCharachters[place];

                    place++;

                    if (place == word.Length)
                    {
                        place = 0;
                    }
                }
            }

            string output = "";

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // go left
                    #region
                    int value = (int)field[i, j];
                    if (j != 0)
                    {
                        string tempString = "" + field[i, j];

                        for (int index = j - 1; index >= 0; index--)
                        {
                            if ((int)field[i, index] > value)
                            {
                                value = (int)field[i, index];
                                tempString += field[i, index];
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (tempString.Length > output.Length)
                        {
                            output = tempString;
                        }
                        else if (tempString.Length == output.Length)
                        {
                            output = GetSmallerValue(tempString, output);
                        }
                    }
                    #endregion

                    //go right
                    #region
                    value = (int)field[i, j];
                    if (j != size - 1)
                    {
                        string tempString = "" + field[i, j];

                        for (int index = j + 1; index < size; index++)
                        {
                            if ((int)field[i, index] > value)
                            {
                                value = (int)field[i, index];
                                tempString += field[i, index];
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (tempString.Length > output.Length)
                        {
                            output = tempString;
                        }
                        else if (tempString.Length == output.Length)
                        {
                            output = GetSmallerValue(tempString, output);
                        }
                    }
                    #endregion

                    //go down
                    #region
                    value = (int)field[i, j];
                    if (i != size - 1)
                    {
                        string tempString = "" + field[i, j];

                        for (int index = i + 1; index < size; index++)
                        {
                            if ((int)field[index, j] > value)
                            {
                                value = (int)field[index, j];
                                tempString += field[index, j];
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (tempString.Length > output.Length)
                        {
                            output = tempString;
                        }
                        else if (tempString.Length == output.Length)
                        {
                            output = GetSmallerValue(tempString, output);
                        }
                    }
                    #endregion

                    //go up
                    #region
                    value = (int)field[i, j];
                    if (i != 0)
                    {
                        string tempString = "" + field[i, j];

                        for (int index = i - 1; index >= 0; index--)
                        {
                            if ((int)field[index, j] > value)
                            {
                                value = (int)field[index, j];
                                tempString += field[index, j];
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (tempString.Length > output.Length)
                        {
                            output = tempString;
                        }
                        else if (tempString.Length == output.Length)
                        {
                            output = GetSmallerValue(tempString, output);
                        }

                    }
                    #endregion
                }
            }

            Console.WriteLine(output);
        }
    }

    private static string GetSmallerValue(string tempString, string output)
    {
        bool same = true;

        for (int i = 0; i < tempString.Length; i++)
        {
            if ((int)tempString[i] > (int)output[i])
            {
                break;
            }
            else if ((int)tempString[i] < (int)output[i])
            {
                same = false;
                break;
            }
        }

        if (same == true)
        {
            return output;
        }
        else
        {
            return tempString;
        }
    }

}
