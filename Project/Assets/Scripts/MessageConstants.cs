using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public static class MessageConstants
{
    public static class Challenge1
    {
        public static string sign = "Everything is not what it seems. Watch your steps\n" +
            "But don't be afraid to take risks";
    }

    public static class Challenge2
    {
        public static string sign = "Planning through observation is key. Practice makes perfect\n" +
            "Defeat is not an option";
    }

    public static class Challenge3
    {
        public static string sign = "You came this far so believe in your skills\n"
            + "Push it to the limit\n" 
            + "P/s: It's not a bug, it's a feature.";
    }

    public static class WorldMessage
    {
        public static string deadPlayer = "You are dead. Press R to restart level";
        public static string level1 = "Level 1";
        public static string level2 = "Level 2";
        public static string win = "Congrats! You made it through. Press E to continue";
        public static string story = "Welcome to Phungia: " +
            "Follow the signs and you will understand the world\n";
    }
}