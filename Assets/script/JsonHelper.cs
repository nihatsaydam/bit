using UnityEngine;

public static class JsonHelper
{
    // Verilen JSON dizisini belirtilen türde bir diziye dönüştüren genel bir metot
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.items;
    }

    // JSON nesnesinin sarmalanması için gerekli sınıf
    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] items;
    }
}
