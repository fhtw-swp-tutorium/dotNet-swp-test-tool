#language: de
#noinspection SpellCheckingInspection

Funktionalität: Beobachter

  Grundlage:
    Gegeben sei eine Liste von Klassen mit dem Attribut "Subject"
    Dann darf diese Liste nicht leer sein

  Szenario: Alle Subjekte sollen eine Methode zum Hinzufügen eines Beobachters bieten
    Wenn ich in jeder Klasse nach einer Methode mit dem Attribut "RegisterObserver" suche
    Dann erwarte ich mir jeweils genau eine Methode

  Szenario: Eine Methode zum Hinzufügen eines Beobachters muss strukturell korrekt sein
    Wenn ich in jeder Klasse nach einer Methode mit dem Attribut "RegisterObserver" suche
    Dann erwarte ich mir eine Methode, die mit einem dieser Präfixe beginnt: "add, register, attach, subscribe"
    Und jede Methode muss genau "1" Parameter haben
    Und jeder Parameter muss ein Interface sein

  Szenario: Alle Subjekte sollen eine Methode zum Entfernen eines Beobachters bieten
    Wenn ich in jeder Klasse nach einer Methode mit dem Attribut "UnregisterObserver" suche
    Dann erwarte ich mir jeweils genau eine Methode

  Szenario: Eine Methode zum Entfernen eines Beobachters muss strukturell korrekt sein
    Wenn ich in jeder Klasse nach einer Methode mit dem Attribut "UnregisterObserver" suche
    Dann erwarte ich mir eine Methode, die mit einem dieser Präfixe beginnt: "remove, unregister, detach, unsubscribe"
    Und jede Methode muss genau "1" Parameter haben
    Und jeder Parameter muss ein Interface sein

  Szenario: Alle Subjekte sollen eine Methode zum Aktualisieren der Beobachters bieten
    Wenn ich in jeder Klasse nach einer Methode mit dem Attribut "NotifyObservers" suche
    Dann erwarte ich mir jeweils genau eine Methode

  Szenario: Eine Methode zum Aktualisieren der Beobachter muss strukturell korrekt sein
    Wenn ich in jeder Klasse nach einer Methode mit dem Attribut "NotifyObservers" suche
    Dann erwarte ich mir eine Methode, die mit einem dieser Präfixe beginnt: "update, notify"
    Und jede Methode muss genau "0" Parameter haben


  Szenario: Beobachter sollen aufgerufen werden, wenn sie registriert sind
    Gegeben sei eine Instanz des Subjekts
    Und eine Instanz des Beobachters
    Wenn ich diesen Beobachter hinzufügen
    Und die Methode zum Aktualisieren aufrufe
    Dann soll mindestens eine Methode des Beobachters aufgerufen werden

  Szenario: Beobachter sollen nicht mehr aufgerufen werden, wenn sie sich vom Subjekt abmelden
    Gegeben sei eine Instanz des Subjekts
    Und eine Instanz des Beobachters
    Wenn ich diesen Beobachter hinzufügen
    Und ich diesen Beobachter entferne
    Und die Methode zum Aktualisieren aufrufe
    Dann soll keine Methode des Beobachters aufgerufen werden