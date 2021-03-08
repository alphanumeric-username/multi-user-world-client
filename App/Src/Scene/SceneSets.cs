using System.Collections.Generic;

namespace Client.App.Scene {
    public static class SceneSets
    {
        public static Dictionary<string, SceneFactory> DefaultSceneSet { get; private set; } = new Dictionary<string, SceneFactory>() {
            { "_initial", MenuScene.Factory },
            { "menu", MenuScene.Factory }
        };
        
        public static Dictionary<string, SceneFactory> TestSceneSet { get; private set; } = new Dictionary<string, SceneFactory>() {
            { "_initial", TextTestScene.Factory },
            { "text", TextTestScene.Factory },
        };
    }
}