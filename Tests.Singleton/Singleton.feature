#language: de

Funktionalität: Singleton

Szenario: Es existiert mindestens ein Singleton
	Gegeben sei mindestens ein Singleton

Szenario: Singletons haben zum Instanzzugriff ein passendes Property oder eine passende Methode
	Gegeben sei mindestens ein Singleton
	Dann bieten Singletons eine passende Methode zur Instanzierung

Szenario: Singletons haben privaten Konstruktur
	Gegeben sei mindestens ein Singleton
	Dann haben singletons einen privaten Konstruktor

Szenario: Singletons soll immer dieselbe Instanz zurückgeben
	Gegeben sei mindestens ein Singleton
	Dann geben singletons immer dieselbe Instanz zurück