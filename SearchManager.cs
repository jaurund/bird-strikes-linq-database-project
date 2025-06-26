using System;

public class SearchManager
{
    // Declare the delegate type for search input events
    public delegate void SearchInputHandler(string input);

    // Declare the event based on that delegate
    public event SearchInputHandler? OnSearchInput;

    // Method to trigger the event
    public void ProcessSearch(string input)
    {
        OnSearchInput?.Invoke(input);
    }
}
