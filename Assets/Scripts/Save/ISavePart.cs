using System;

namespace GitHubUnityTable.Save
{
    public interface ISavePart
    {
        event Action<ISavePart> OnChanged;
    }
}