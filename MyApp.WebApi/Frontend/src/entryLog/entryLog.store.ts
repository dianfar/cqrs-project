import axios from "axios";
import { IEntryLog } from "./EntryLog";

export class EntryLogStore {
    async getEntryLogs(): Promise<IEntryLog[]> {
        let response = await axios.get("/api/entryLogs");
        let logs = response.data as IEntryLog[];
        return logs;
    }
}

const entryLogStore = new EntryLogStore();

export default entryLogStore;