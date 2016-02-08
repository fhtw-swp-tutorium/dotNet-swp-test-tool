Funktionalität: Observer

Szenario: Es existiert mindestens ein Subjekt
	Gegeben sei mindestens ein Subjekte

Szenario: Subjekte haben eine Register Methode, welche als einzigen Paramter ein Interface entgegennimmt
	Gegeben sei mindestens ein Subjekte
	Dann haben Subjekte eine passende Register Methode
	
Szenario: Subjekte haben eine Unregister Methode, welche als einzigen Paramter ein Interface entgegennimmt
	Gegeben sei mindestens ein Subjekte
	Dann haben Subjekte eine passende Unregister Methode
 
Szenario: Subjekte haben eine Update Methode, welche keinen Parameter entgegennimmt
	Gegeben sei mindestens ein Subjekte
	Dann haben Subjekte eine passende Update Methode

Szenario: Observer kann sich bei Subjekt registieren und wird danach geupdated
	Gegeben sei mindestens ein Subjekte
	Dann haben Subjekte eine passende Register Methode
	Dann haben Subjekte eine passende Update Methode
	Wenn sich bei allen Subjekten je ein Observer mit den Namen "TestObserver" registiert
	Wenn Subjekte die Update Methode Aufrufen
	Wenn Subjekte die Update Methode Aufrufen
	Dann sollen alle Observer "TestObserver" "2" mal aufgerufen worden sein

Szenario: Observer kann sich bei Subjekt abmelden und wird danach nicht mehr geupdated
	Gegeben sei mindestens ein Subjekte
	Dann haben Subjekte eine passende Register Methode
	Dann haben Subjekte eine passende Update Methode
	Dann haben Subjekte eine passende Unregister Methode
	Wenn sich bei allen Subjekten je ein Observer mit den Namen "TestObserver" registiert
	Wenn Subjekte die Update Methode Aufrufen
	Wenn Subjekte die Update Methode Aufrufen
	Dann sollen alle Observer "TestObserver" "2" mal aufgerufen worden sein
