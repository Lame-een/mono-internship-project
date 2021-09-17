var modelColumns =
{
    serveruser: [{"username":"Username"}, {"role": "Role"}],
    lyrics: [{"verified":"Is verified"}],
    song:[{"songName":"Song Name"}, {"albumName":"Album Name"}, {"artistName":"Artist Name"}],
    genre:[{"name":"Name"}],
    album:[{"albumName":"Album Name"}, {"artistName":"Artist Name"}],
    artist:[{"name":"Name"}]
};

export default function getModelColumns(modelName)
{
    return modelColumns[modelName];
}