var modelColumns =
{
    serveruser: [{"username":"Username"}, {"role": "Role"}],
    lyrics: [{"verified":"Is verified"}],
    song:[{"name":"Name"}],
    genre:[{"name":"Name"}],
    album:[{"name":"Name"}, {"numberOfTracks":"Number of Tracks"}, {"year":"Release year"}],
    artist:[{"name":"Name"}],
    songComposite:[{"songName":"Song Name"}, {"albumName":"Album Name"}, {"artistName":"Artist Name"}, {"genreName":"Genre Name"}]
};

export default function getModelColumns(modelName)
{
    return modelColumns[modelName];
}