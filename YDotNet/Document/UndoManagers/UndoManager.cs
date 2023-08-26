using YDotNet.Document.Types.Branches;
using YDotNet.Infrastructure;
using YDotNet.Native.UndoManager;

namespace YDotNet.Document.UndoManagers;

/// <summary>
///     The <see cref="UndoManager" /> is used to perform undo/redo operations over shared types in a <see cref="Doc" />.
/// </summary>
public class UndoManager
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="UndoManager" /> class.
    /// </summary>
    /// <param name="doc">The <see cref="Doc" /> to operate over.</param>
    /// <param name="branch">The shared type in the <see cref="Doc" /> to operate over.</param>
    /// <param name="options">The options to initialize the <see cref="UndoManager" />.</param>
    public UndoManager(Doc doc, Branch branch, UndoManagerOptions options)
    {
        var optionsHandle = MemoryWriter.WriteStruct(UndoManagerOptionsNative.From(options));

        Handle = UndoManagerChannel.NewWithOptions(doc.Handle, branch.Handle, optionsHandle);

        MemoryWriter.Release(optionsHandle);
    }

    /// <summary>
    ///     Gets the handle to the native resource.
    /// </summary>
    internal nint Handle { get; }
}
