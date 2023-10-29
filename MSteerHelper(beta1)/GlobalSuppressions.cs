// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Usage", "CA1816:Методы Dispose должны вызывать SuppressFinalize", Justification = "<Ожидание>", Scope = "member", Target = "~M:MSteer.GameControls.System#IDisposable#Dispose")]
[assembly: SuppressMessage("Usage", "CA1816:Методы Dispose должны вызывать SuppressFinalize", Justification = "<Ожидание>", Scope = "member", Target = "~M:KeyboardPedals.Dispose")]
[assembly: SuppressMessage("Usage", "CA1816:Методы Dispose должны вызывать SuppressFinalize", Justification = "<Ожидание>", Scope = "member", Target = "~M:MSteerHelp.KeyboardPedals.System#IDisposable#Dispose")]
[assembly: SuppressMessage("Usage", "CA1816:Методы Dispose должны вызывать SuppressFinalize", Justification = "<Ожидание>", Scope = "member", Target = "~M:MSteerHelp.MouseSteering.Dispose")]
[assembly: SuppressMessage("Usage", "CA1816:Методы Dispose должны вызывать SuppressFinalize", Justification = "<Ожидание>", Scope = "member", Target = "~M:MSteerHelp.VJoyController.Dispose")]
[assembly: SuppressMessage("Usage", "CA2201:Не порождайте исключения зарезервированных типов", Justification = "<Ожидание>", Scope = "member", Target = "~M:MSteerHelp.VJoyController.SetPedalAxis(System.Int32,System.Int32,System.Exception)")]
[assembly: SuppressMessage("CodeQuality", "IDE0076:Недопустимый глобальный атрибут \"SuppressMessageAttribute\"", Justification = "<Ожидание>")]
[assembly: SuppressMessage("Usage", "CA2201:Не порождайте исключения зарезервированных типов", Justification = "<Ожидание>", Scope = "member", Target = "~M:MSteer.GameControls.UpdateControls")]
[assembly: SuppressMessage("Design", "CA1050:Объявите типы в пространствах имен", Justification = "<Ожидание>", Scope = "type", Target = "~T:MainWindow")]
