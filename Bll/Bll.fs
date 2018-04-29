namespace Bll

module Say =
    open System

    let hello() =
        "Hello user #" + Guid.NewGuid().ToString()
