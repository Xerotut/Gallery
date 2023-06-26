
public struct WebObject<T>
{
    public string url { get; }
    public T webObject { get; }

    public WebObject(string url, T webObject)
    {
        this.url = url;
        this.webObject = webObject;
    }

    
}
