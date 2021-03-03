using System;
using System.Collections.Generic;
using Client.App.Scene;
using Xunit;

namespace Client.Tests
{
    class SceneA: AbstractScene {
        public static SceneFactory Factory = (object args) => new SceneA();
    }
    class SceneB: AbstractScene {
        public static SceneFactory Factory = (object args) => new SceneB();
    }

    public class SceneTests
    {
        static Dictionary<string, SceneFactory> sceneSet = new Dictionary<string, SceneFactory>() {
            { "_initial", SceneA.Factory },
            { "scene-a", SceneA.Factory },
            { "scene-b", SceneB.Factory },
        };

        [Fact]
        public void SceneManagerRequestTransition_ValidSceneID_ChangeCurrentScene() {
            SceneManager sceneManager = new SceneManager(sceneSet);
            Assert.IsType<SceneA>(sceneManager.CurrentScene);

            sceneManager.RequestTransition("scene-b", null);
            Assert.IsType<SceneB>(sceneManager.CurrentScene);
        }

        [Fact]
        public void SceneManagerRequestTransition_InvalidSceneID_ThrowException() {
            SceneManager sceneManager = new SceneManager(sceneSet);

            Assert.Throws<ArgumentOutOfRangeException>(() => sceneManager.RequestTransition("invalid-scene", null));
        }
    }
}