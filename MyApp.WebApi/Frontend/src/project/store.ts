import { IObservableArray, observable } from "mobx";
import axios from "axios";
import { IProject, IAddProject, IEditProject } from "./interface";

export class ProjectStore {
    async getProjects(): Promise<IProject[]> {
        let response = await axios.get("/api/projects");
        let projects = response.data as IProject[];
        return projects;
    }

    async getAddProject(): Promise<IAddProject> {
        let response = await axios.get(`/api/projects/add`);
        let addProject = response.data as IAddProject;
        return addProject;
    }

    async getEditProject(projectId: string): Promise<IEditProject> {
        let response = await axios.get(`/api/projects/${projectId}/edit`);
        let editProject = response.data as IEditProject;
        return editProject;
    };

    async updateProject(project: IEditProject): Promise<void> {
        await axios.put(`/api/projects/`, project);
    }

    async addProject(project: IProject): Promise<void> {
        await axios.post(`/api/projects/`, project);
    }

    async deleteProject(projectId: string): Promise<void> {
        await axios.delete(`/api/projects/${projectId}`);
    }
}

const projectStore = new ProjectStore();

export default projectStore;