<Query Kind="Statements" />

var oldNotes = "Lovey should do something here.";
var patchedNotes = "Nicole can do her thing.";
var note = patchedNotes.Replace(oldNotes, "").Trim();
note = note + " " + oldNotes;
note.Dump();


var date = DateTime.Today.ToShortDateString();
date.Dump();