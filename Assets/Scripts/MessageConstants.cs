using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class MessageConstants
{
    public static class Challenge1
    {
        public static string sign = "First rule of Phungia: Have faith";
    }

    public static class Challenge2
    {
        public static string sign = "Second rule of Phungia: Prepare for the worst";
    }

    public static class Challenge3
    {
        public static string sign = "It's not a bug, it's a feature";
    }

    public static class WorldMessage
    {
        public static string deadPlayer = "You are dead. Press R to restart level";
        public static string level1 = "Level 1";
        public static string level2 = "Level 2";
        public static string win = "Congrats! You made it through. Press E to continue";
        public static string story = "Welcome to Phungia\n" +
            "You have woken up here, not knowing who you are, where you came from\n" +
            "To survive, embrace the rules of Phungia world\n" +
            "Follow the signs left by ancient beings, they will guide you well";
    }
}