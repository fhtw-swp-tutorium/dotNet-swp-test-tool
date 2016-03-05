Funktionalität: Command

Szenario: Es existiert ein Invoker der eine Methode mit dem Attribut InvokeCommand hat
	Gegeben sei mindestens ein Invoker

Szenario: Der InvokeCommand hat genau einen Paramter und dieser ist ein Interface
	Gegeben sei mindestens ein Invoker
	Dann hat die InvokeCommand Methode genau einen Parameter und dieser ist ein Interface

Szenario: Es gibt mindestens eine Implementierung des Interface Paramteres der InvokeCommand Methode
	Gegeben sei mindestens ein Invoker
	Dann hat die InvokeCommand Methode genau einen Parameter und dieser ist ein Interface
	Dann hat der Interface Parameter der InvokeCommand Methode mindestens eine Implementierung
	
#Invoke Commmand ist der Name des Attributes welches über die Methode gelegt werden kann, 
Szenario: Wenn die InovkeCommand Methode aufgerufen wird, wird mindestens eine Methode des Commands aufgerufen
	Gegeben sei mindestens ein Invoker
	Dann hat die InvokeCommand Methode genau einen Parameter und dieser ist ein Interface
	Wenn man die die InvokeCommand Methode mit dem Command "TestCommand" aufruft
	Dann wurde mindestens eine Methode des "TestCommand" aufgerufen

