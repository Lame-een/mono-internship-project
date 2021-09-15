var modelColumns =
{
    serveruser: [{"username":"Username"}, {"role": "Role"}],
    lyrics: [{"verified":"Is verified"}],
    //song:[{"name":"Name"}],
    song:[{"songName":"Song Name"}, {"albumName":"Album Name"}, {"artistName":"Artist Name"}],
    genre:[{"name":"Name"}],
    //album:[{"name":"Name"}, {"numberOfTracks":"Number of Tracks"}, {"year":"Release year"}],
    album:[{"albumName":"Album Name"}, {"artistName":"Artist Name"}],
    artist:[{"name":"Name"}]
};

export default function getModelColumns(modelName)
{
    return modelColumns[modelName];
}