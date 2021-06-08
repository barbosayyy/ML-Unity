# ML Unity
 My implementation of Machine Learning in a project using Unity's MLagents

PS: The missing packages are from MLagents release 17 (com.unity.ml-agents & com.unity.ml-agents.extensions)

How to use ML:

Creating a new Brain:

//Check Unity MLAgents Github documentation for clarification.

1- Install latest version of python and pytorch. (Check MLAgents GitHub for setup)
2- Run a virtual environment of python inside the project folder.
3- Make sure the Agent's Behavior Parameters is running with Default Behavior type and GPU as Inference device, as well as NN model set to None.
4- Run mlagents-learn or mlagents-learn --force to start teaching the new brain. Hit Play in Unity.
5- Wait until the desired amount of steps, CTRL+C in python virtual environment and then apply the new Brain to the Agent.

Testing the brain in Assets folder:

1- Apply brain to Agent's NN model.
2- Change Inference Device to Default and Behavior Type to Inference only.
