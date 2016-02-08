Funktionalität: Observer

Szenario: Es existiert mindest ein Subjekt
	Gegeben sei Zugriff auf alle verfügbaren Subjekte
	Dann existiert mindestens ein Subjekt

Szenario: Subjekte haben eine Register Methode
	Gegeben sei Zugriff auf alle verfügbaren Subjekte
	Dann existiert mindestens ein Subjekt
	Dann sollen alle Subjekte eine Reigster Methode haben
	
Szenario: Subjekte haben eine Unregister Methode
	Gegeben sei Zugriff auf alle verfügbaren Subjekte
	Dann existiert mindestens ein Subjekt
	Dann sollen alle Subjekte eine Reigster Methode haben
 
Szenario: Subjekte haben eine Update Methode
	Gegeben sei Zugriff auf alle verfügbaren Subjekte
	Dann existiert mindestens ein Subjekt
	Dann sollen alle Subjekte eine Update Methode haben

Szenario: Observer kann sich bei Subjekt registieren
	Gegeben sei Zugriff auf alle verfügbaren Subjekte
	Dann existiert mindestens ein Subjekt
	Dann sollen alle Subjekte eine Reigster Methode haben
	Dann sollen alle Subjekte eine Update Methode haben
	Wenn sich bei jedem Subjekt ein Observer mit den Namen "TestObserver" registiert
	Wenn alle Subjekte die Update Methode Aufrufen
	Wenn alle Subjekte die Update Methode Aufrufen
	Dann sollen "TestObserver" "2" mal aufgerufen worden sein

	

