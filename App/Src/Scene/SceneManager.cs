using System;
using System.Collections.Generic;

namespace Client.App.Scene
{
    public class SceneManager
    {
        public AbstractScene CurrentScene { get; private set; }
        public Dictionary<string, SceneFactory> SceneSet { get; private set; }
        
        public SceneManager(Dictionary<string, SceneFactory> sceneSet, object initialSceneArgs = null)
        {
            SceneSet = sceneSet;
            this.RequestTransition("_initial", initialSceneArgs);
        }
        
        public void RequestTransition(string sceneID, object args) {
            SceneFactory nextSceneFactory = SceneSet.GetValueOrDefault(sceneID);
            if (nextSceneFactory == null) {
                throw new ArgumentOutOfRangeException(sceneID);
            }
            AbstractScene nextScene = nextSceneFactory(args);
            nextScene.BeforeAttach();
            this.CurrentScene = nextScene;
            nextScene.sceneManager = this;
            nextScene.AfterAttach();
        }
    }
}